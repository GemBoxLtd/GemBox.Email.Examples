Imports GemBox.Email
Imports GemBox.Email.Graph
Imports System

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create a new Graph client.
        Dim graphClient = New GraphClient()
        graphClient.Authenticate("<OAUTH2.0-TOKEN>")
        graphClient.ImpersonateUser("<USER-ID-OR-EMAIL>")

        ' Search for messages in "Inbox" folder whose subject contains "Some subject" text.
        Dim messages = graphClient.SearchMessages("Inbox", "contains(subject, 'Some subject')")
        Console.WriteLine("Number of messages with ""Some subject"" in subject:")
        Console.WriteLine(messages.Count)

        ' Search for messages in "Inbox" folder that were received this year.
        messages = graphClient.SearchMessages("Inbox", $"receivedDateTime ge {Date.Now.Year}-01-01")
        Console.WriteLine("Number of messages received this year:")
        Console.WriteLine(messages.Count)

    End Sub
End Module
