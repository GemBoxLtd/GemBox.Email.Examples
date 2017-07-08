Imports System
Imports System.Text
Imports GemBox.Email

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Load message
        Dim message As MailMessage = MailMessage.Load("Html.eml")
        Dim sb As New StringBuilder()

        ' Add date
        sb.AppendLine(String.Format("Date: {0}", message.Date))

        ' Add addresses
        sb.AppendLine(String.Format("From: {0}", message.From.ToString()))
        sb.AppendLine(String.Format("To: {0}", message.To.ToString()))

        If message.Cc.Count > 0 Then
            sb.AppendLine(String.Format("From: {0}", message.Cc.ToString()))
        End If

        If message.Bcc.Count > 0 Then
            sb.AppendLine(String.Format("From: {0}", message.Bcc.ToString()))
        End If

        If message.Attachments.Count > 0 Then
            sb.AppendLine(String.Format("Attachments: {0}", message.Attachments.Count.ToString()))
        End If

        ' Add subject
        sb.AppendLine(String.Format("Subject: {0}", message.Subject))

        ' Add message body
        sb.AppendLine("------------------------------ BODY ------------------------------")
        If String.IsNullOrEmpty(message.BodyHtml) Then
            sb.Append(message.BodyText)
        Else
            sb.Append(message.BodyHtml)
        End If

        Console.WriteLine(sb.ToString())

    End Sub

End Module