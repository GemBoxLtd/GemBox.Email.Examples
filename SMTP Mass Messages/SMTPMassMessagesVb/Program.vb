Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading
Imports System.Threading.Tasks
Imports GemBox.Email
Imports GemBox.Email.Smtp

Module Program

    Const Host As String = "<HOST>"
    Const Username As String = "<USERNAME>"
    Const Password As String = "<PASSWORD>"
    Const Sender As String = "<ADDRESS>"

    Dim SentEmailCounter As Integer = 0

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Dim mailingList As New List(Of String)() From
        {
            "first.receiver@example.com",
            "second.receiver@example.com",
            "third.receiver@example.com",
            "..."
        }

        Dim chunkSize As Integer = 80

        ' Split "mailingList" to multiple lists of "chunkSize" size.
        Dim mailingChunks = SplitMany(mailingList, chunkSize)

        ' Process each "mailingChunks" chunk as a separate Task.
        Dim sendMailingChunks As IEnumerable(Of Task) = mailingChunks.Select(
            Function(mailingChunk) Task.Run(Sub() SendEmails(mailingChunk)))

        ' Create a Task that will complete when emails were sent to all the "mailingList".
        Dim sendBuilkEmails As Task = Task.WhenAll(sendMailingChunks)

        ' Displaying the progress of bulk email sending.
        While Not sendBuilkEmails.IsCompleted
            Console.WriteLine($"{SentEmailCounter} emails have been sent!")
            Task.Delay(1000).Wait()
        End While
    End Sub

    Sub SendEmails(ByVal recipients As IEnumerable(Of String))

        Using smtp As New SmtpClient(Host)
            smtp.Connect()
            smtp.Authenticate(Username, Password)

            For Each recipient In recipients
                Dim message As New MailMessage(Sender, recipient) With
                {
                    .Subject = "New Blog Post",
                    .BodyText = "Dear reader," & vbLf &
                        "We have released a new blog post." & vbLf &
                        "You can find it on: https://www.gemboxsoftware.com/company/blog"
                }

                smtp.SendMessage(message)
                Interlocked.Increment(SentEmailCounter)
            Next
        End Using

    End Sub

    Function SplitMany(ByVal source As List(Of String), ByVal size As Integer) As List(Of List(Of String))

        Dim sourceChunks As New List(Of List(Of String))()

        For i As Integer = 0 To source.Count - 1 Step size
            sourceChunks.Add(source.GetRange(i, Math.Min(size, source.Count - i)))
        Next

        Return sourceChunks

    End Function

End Module