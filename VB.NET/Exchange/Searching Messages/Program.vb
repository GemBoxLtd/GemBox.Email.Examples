Imports System
Imports GemBox.Email
Imports GemBox.Email.Exchange

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Dim exchangeClient As New ExchangeClient("<HOST> (e.g. https://outlook.office365.com/EWS/Exchange.asmx)")
        exchangeClient.Authenticate("<USERNAME>", "<PASSWORD>")

        ' Search for messages in "Inbox" folder whose subject contains "Some subject" text.
        Dim messageInfos = exchangeClient.SearchMessages("Inbox", "subject:""Some subject""")
        Console.WriteLine("Number of messages with ""Some subject"" in subject:")
        Console.WriteLine(messageInfos.Count)

        ' Search for messages in "Inbox" folder that were received this year.
        messageInfos = exchangeClient.SearchMessages("Inbox", "received:""this year""")
        Console.WriteLine("Number of messages received this year:")
        Console.WriteLine(messageInfos.Count)

    End Sub
End Module