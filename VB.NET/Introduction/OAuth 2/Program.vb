Imports GemBox.Email
Imports GemBox.Email.Exchange
Imports GemBox.Email.Graph
Imports GemBox.Email.Imap
Imports GemBox.Email.Pop
Imports GemBox.Email.Smtp
Imports System

Module Program

    Sub Main()
        Example1()
        Example2()
        Example3()
        Example4()
        Example5()
    End Sub

    Sub Example1()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create a new IMAP client.
        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")

            '  Connect and sign to IMAP server using OAuth 2.0.
            imap.Connect()
            imap.Authenticate("<USERNAME>", "<ACCESS-TOKEN>", ImapAuthentication.XOAuth2)
            Console.WriteLine("Authenticated.")
        End Using
    End Sub

    Sub Example2()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create a new POP client.
        Using pop As New PopClient("<ADDRESS> (e.g. pop.gmail.com)")

            '  Connect and sign to POP server using OAuth 2.0.
            pop.Connect()
            pop.Authenticate("<USERNAME>", "<ACCESS-TOKEN>", PopAuthentication.XOAuth2)
            Console.WriteLine("Authenticated.")
        End Using
    End Sub

    Sub Example3()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create a new SMTP client.
        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)")

            '  Connect and sign to SMTP server using OAuth 2.0.
            smtp.Connect()
            smtp.Authenticate("<USERNAME>", "<ACCESS-TOKEN>", SmtpAuthentication.XOAuth2)
            Console.WriteLine("Authenticated.")
        End Using
    End Sub

    Sub Example4()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create a new Exchange client.
        Dim exchangeClient = New ExchangeClient("<HOST> (e.g. https://outlook.office365.com/EWS/Exchange.asmx)")
        ' Authenticate the client using OAuth 2.0.
        exchangeClient.Authenticate("<USERNAME>", "<ACCESS-TOKEN>", ExchangeAuthentication.OAuth2)
    End Sub

    Sub Example5()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create a new Graph client.
        Dim graphClient = New GraphClient()
        ' Authenticate the client using OAuth 2.0.
        graphClient.Authenticate("<ACCESS-TOKEN>")
    End Sub

End Module
