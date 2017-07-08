Imports System
Imports GemBox.Email
Imports GemBox.Email.Pop

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using pop As New PopClient("<ADDRESS> (e.g. pop.gmail.com)")

            ' Connect and login
            pop.Connect()
            Console.WriteLine("Connected.")

            pop.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")

            ' Check if there are any messages available on the server
            If pop.GetCount() = 0 Then Exit Sub

            ' Download message with sequence number 1 (first one)
            Dim message As MailMessage = pop.GetMessage(1)

            'Display message sender and subject
            Console.WriteLine("From: " & message.From.ToString())
            Console.WriteLine("Subject: " & message.Subject)

            ' Write message body
            Console.WriteLine("Body:")

            Dim text As String

            If message.BodyHtml IsNot Nothing Then
                text = message.BodyHtml
            Else
                text = message.BodyText
            End If

            For Each line As String In text.Split(New String() {vbCrLf}, StringSplitOptions.None)
                Console.WriteLine(" "c & line)
            Next

        End Using

    End Sub

End Module