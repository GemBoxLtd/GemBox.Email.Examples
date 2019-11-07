Imports System
Imports GemBox.Email
Imports GemBox.Email.Mime
Imports GemBox.Email.Pop

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using pop As New PopClient("<ADDRESS> (e.g. pop.gmail.com)")

            pop.Connect()
            pop.Authenticate("<USERNAME>", "<PASSWORD>")

            ' Get headers for first available mail message.
            Dim headers As HeaderCollection = pop.GetHeaders(1)

            ' Display message headers.
            For Each header As Header In headers
                Console.WriteLine($"{header.Name}: {header.Body}")
            Next
        End Using
    End Sub
End Module