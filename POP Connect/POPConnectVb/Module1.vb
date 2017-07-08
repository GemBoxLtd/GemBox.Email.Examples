Imports System
Imports GemBox.Email
Imports GemBox.Email.Pop

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using pop As New PopClient("<ADDRESS> (e.g. pop.gmail.com)")

            ' Connect to mail server
            pop.Connect()
            Console.WriteLine("Connected.")

            ' Authenticate with specified username and password
            ' (PopClient will use strongest possible authentication mechanism)
            pop.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")

        End Using

    End Sub

End Module