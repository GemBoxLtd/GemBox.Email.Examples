Imports System
Imports System.Linq
Imports GemBox.Email
Imports GemBox.Email.Calendar

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new message.
        Dim message = New MailMessage(New MailAddress("sender@example.com", "Sender"),
                                      New MailAddress("first.receiver@example.com", "First receiver"))

        message.Subject = "This is a mail message with a calendar"
        message.BodyText = "Hi! I am sending you my calendar."

        ' Create new calendar.
        Dim calendar As Calendar = New Calendar
        Dim e As [Event] = New [Event]
        e.Organizer = message.Sender
        e.Name = "GemBox conference"
        e.Start = new DateTime(2018, 1, 10, 9, 0, 0, DateTimeKind.Utc)
        e.End = new DateTime(2018, 1, 12, 18, 0, 0, DateTimeKind.Utc)
        e.Attendees.Add(message.To.First)
        calendar.Events.Add(e)

        ' Add a calendar to the mail message.
        message.Calendars.Add(calendar)

        ' ... a mail message can be sent using SMTP or saved to a file.
        message.Save("Add Calendar to a Message.eml")

    End Sub

End Module