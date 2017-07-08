Imports System
Imports System.Globalization
Imports GemBox.Email
Imports GemBox.Email.Pop

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using pop As New PopClient("<ADDRESS> (e.g. pop.gmail.com)")
            pop.Connect()
            Console.WriteLine("Connected.")

            pop.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")

            ' Read the number of currently available email messages on the server.
            Dim count As Integer = pop.GetCount()
            Console.WriteLine("Number of available messages: " & count)

            ' Write table header
            Console.WriteLine()
            Console.WriteLine(" NO. |         DATE        |        SUBJECT")
            Console.WriteLine("--------------------------------------------------")

            ' Receive (download) and list all email messages.
            For i As Integer = 1 To count
                Dim message As MailMessage = pop.GetMessage(i)
                Console.WriteLine("  {0,-2} | {1} | {2}", i, message.Date.ToString(CultureInfo.InvariantCulture), message.Subject)
            Next
        End Using

    End Sub

End Module