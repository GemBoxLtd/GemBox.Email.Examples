Imports GemBox.Email
Imports GemBox.Email.Pop
Imports GemBox.Email.Security
Imports System
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create certificate validation delegate.
        Dim validationDelegate As RemoteCertificateValidationCallback =
            Function(sender As Object,
                     certificate As X509Certificate,
                     chain As X509Chain,
                     errors As SslPolicyErrors) As Boolean

                If errors = SslPolicyErrors.None OrElse errors = SslPolicyErrors.RemoteCertificateNameMismatch Then
                    Console.WriteLine("Server certificate is valid.")
                    Return True
                Else
                    Console.WriteLine($"Server certificate is invalid: {errors}")
                    Return False
                End If
            End Function

        ' Create new PopClient and specify host, port, security and certificate validation callback.
        Using pop As New PopClient(
            "<ADDRESS> (e.g. pop.gmail.com)",
            995,
            ConnectionSecurity.Ssl,
            validationDelegate)

            ' Connect to email server.
            pop.Connect()
            Console.WriteLine("Connected.")

            ' Authenticate with specified username, password and authentication mechanism.
            pop.Authenticate("<USERNAME>", "<PASSWORD>", PopAuthentication.Plain)
            Console.WriteLine("Authenticated.")
        End Using

    End Sub
End Module
