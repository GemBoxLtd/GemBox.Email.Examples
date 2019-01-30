Imports System
Imports GemBox.Email
Imports GemBox.Email.Pop

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using pop As New PopClient("<ADDRESS> (e.g. pop.gmail.com)")

            pop.Connect()
            pop.Authenticate("<USERNAME>", "<PASSWORD>")

            ' Get number of available messages.
            Console.WriteLine($"Mailbox message count: {pop.GetCount()}")

            ' Get size of all available messages in bytes
            Console.WriteLine($"Mailbox size: {pop.GetSize()} Byte(s)")
        End Using
    End Sub
End Module