Imports System.IO
Imports System.IO.Compression
Imports GemBox.Email

Module Program

    Sub Main()

        Example1()
        Example2()

    End Sub

    Sub Example1()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new message.
        Dim message As New MailMessage(
            New MailAddress("sender@example.com", "Sender"),
            New MailAddress("receiver@example.com", "Receiver"))

        ' Add subject and body.
        message.Subject = "Save Example by GemBox.Email"
        message.BodyText = "Hi 👋," & vbLf &
            "This message was created and saved with GemBox.Email." & vbLf &
            "Read more about it on https://www.gemboxsoftware.com/email"

        ' Save message to email file.
        message.Save("Save.eml")
    End Sub

    Sub Example2
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Dim message = MailMessage.Load("Attachment.eml")
        Dim zipName As String = Path.ChangeExtension("Attachment.eml", ".zip")

        Using archiveStream = File.OpenWrite(zipName)
            Using archive = New ZipArchive(archiveStream, ZipArchiveMode.Create)

                For Each attachment In message.Attachments
                    Dim attachmentName As String = If(attachment.FileName, Path.GetRandomFileName())
                    Dim entry = archive.CreateEntry(attachmentName)

                    Using entryStream = entry.Open()
                        attachment.Save(entryStream)
                    End Using
                Next

            End Using
        End Using
    End Sub

End Module