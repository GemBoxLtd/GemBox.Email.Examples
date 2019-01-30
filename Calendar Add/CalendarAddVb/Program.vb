Imports System
Imports System.Linq
Imports GemBox.Email
Imports GemBox.Email.Calendar

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new message.
        Dim message As New MailMessage("sender@example.com", "receiver@example.com")

        message.Subject = "Mail Message With Calendar"
        message.BodyText = "Hi! I am sending you my calendar."

        ' Create new calendar.
        Dim calendar As New Calendar()
        Dim ev As New [Event]()
        ev.Organizer = message.Sender
        ev.Name = "GemBox Meeting Request"
        ev.Start = New DateTime(2018, 1, 10, 9, 0, 0, DateTimeKind.Utc)
        ev.End = New DateTime(2018, 1, 12, 18, 0, 0, DateTimeKind.Utc)
        ev.Attendees.Add(message.To.First)
        calendar.Events.Add(ev)

        ' Add calendar to the mail message.
        message.Calendars.Add(calendar)

        message.Save("Add To Message.eml")
    End Sub
End Module