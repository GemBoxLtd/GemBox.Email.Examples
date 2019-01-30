Imports System
Imports GemBox.Email
Imports GemBox.Email.Pop

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using pop As New PopClient("<ADDRESS> (e.g. pop.gmail.com)")

            ' Connect and login.
            pop.Connect()
            Console.WriteLine("Connected.")

            pop.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")

            ' Check if there are any messages available on the server.
            If pop.GetCount() = 0 Then Exit Sub

            ' Download message with sequence number 1 (the first message).
            Dim message As MailMessage = pop.GetMessage(1)

            ' Display message sender and subject.
            Console.WriteLine()
            Console.WriteLine($"From: {message.From}")
            Console.WriteLine($"Subject: {message.Subject}")

            ' Display message body.
            Console.WriteLine("Body:")
            Dim body As String = If(String.IsNullOrEmpty(message.BodyHtml),
                message.BodyText,
                message.BodyHtml)
            Console.WriteLine(body)
        End Using
    End Sub
End Module