Imports System
Imports System.Collections.Generic
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

            ' Get info for all available messages
            Dim infoList As IList(Of PopMessageInfo) = pop.ListMessages()

            Console.WriteLine("Listing messages...")

            For Each info As PopMessageInfo In infoList
                Console.WriteLine("{0} - [{1}] - {2} Byte(s)", info.Number, info.Uid, info.Size)
            Next

        End Using

    End Sub

End Module