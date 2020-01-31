Imports GemBox.Email

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Convert email from one format into another.
        Dim message As MailMessage = MailMessage.Load("Attachment.eml")
        message.Save("Convert.msg")
    End Sub
End Module