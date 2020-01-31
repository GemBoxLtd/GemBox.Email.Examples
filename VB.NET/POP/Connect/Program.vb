Imports System
Imports GemBox.Email
Imports GemBox.Email.Pop

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new POP client.
        Using pop As New PopClient("<ADDRESS> (e.g. pop.gmail.com)")

            ' By default the connect timeout is 5 sec.
            pop.ConnectTimeout = TimeSpan.FromSeconds(4)

            ' Connect to POP server.
            pop.Connect()
            Console.WriteLine("Connected.")

            ' Authenticate using the credentials; username and password.
            pop.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")
        End Using

        Console.WriteLine("Disconnected.")
    End Sub
End Module