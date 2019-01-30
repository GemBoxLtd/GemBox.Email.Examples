Imports System
Imports GemBox.Email
Imports GemBox.Email.Pop
Imports GemBox.Email.Imap

Module Program

    Sub Main()

        Example1()
        Example2()

    End Sub

    Sub Example1()
        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create POP client.
        Using pop As New PopClient("<ADDRESS> (e.g. pop.gmail.com)")

            '  Connect and sign to POP server.
            pop.Connect()
            pop.Authenticate("<USERNAME>", "<PASSWORD>")

            ' Read the number of currently available emails on the server.
            Dim count As Integer = pop.GetCount()

            Console.WriteLine(" NO. |     DATE     |          SUBJECT          ")
            Console.WriteLine("------------------------------------------------")

            ' Download and receive all email messages.
            For number As Integer = 1 To count

                Dim message As MailMessage = pop.GetMessage(number)

                ' Read and display email's date and subject.
                Console.WriteLine($"  {number}  |  {message.Date.ToShortDateString()}  |  {message.Subject}")
            Next
        End Using
    End Sub

    Sub Example2()
        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create IMAP client.
        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")

            '  Connect and sign to IMAP server.
            imap.Connect()
            imap.Authenticate("<USERNAME>", "<PASSWORD>")

            ' Select INBOX folder.
            imap.SelectInbox()

            ' Read the number of currently available emails in selected mailbox folder.
            Dim count As Integer = imap.SelectedFolder.Count

            Console.WriteLine(" NO. |     DATE     |          SUBJECT          ")
            Console.WriteLine("------------------------------------------------")

            ' Download and receive all email messages from selected mailbox folder.
            For number As Integer = 1 To count

                Dim message As MailMessage = imap.GetMessage(number)

                ' Read and display email's date and subject.
                Console.WriteLine($"  {number}  |  {message.Date.ToShortDateString()}  |  {message.Subject}")
            Next
        End Using
    End Sub
End Module