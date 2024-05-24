Imports System
Imports System.Collections.Generic
Imports GemBox.Email
Imports GemBox.Email.Pop

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using pop As New PopClient("<ADDRESS> (e.g. pop.gmail.com)")

            pop.Connect()
            pop.Authenticate("<USERNAME>", "<PASSWORD>")

            ' Get information about all available messages.
            Dim infos As IList(Of PopMessageInfo) = pop.ListMessages()

            ' Display messages information.
            For Each info As PopMessageInfo In infos
                Console.WriteLine($"{info.Number} - [{info.Uid}] - {info.Size} Byte(s)")
            Next
        End Using
    End Sub
End Module