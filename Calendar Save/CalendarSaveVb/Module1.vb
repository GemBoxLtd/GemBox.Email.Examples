Imports System
Imports GemBox.Email
Imports GemBox.Email.Calendar

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new calendar.
        Dim calendar As Calendar = New Calendar()

        ' Create new event.
        Dim e As [Event] = New [Event]
        e.Organizer = New MailAddress("info@gemboxsoftware.com", "GemBox Ltd")
        e.Name = "GemBox conference"
        e.Location = "152 City Road, London"
        e.Start = new DateTime(2018, 1, 10, 9, 0, 0, DateTimeKind.Utc)
        e.End = new DateTime(2018, 1, 12, 18, 0, 0, DateTimeKind.Utc)
        e.Attendees.Add(New MailAddress("invited@example.com"))

        ' Create new reminder.
        Dim reminder As Reminder = New Reminder
        reminder.ReminderAction = ReminderAction.Email
        reminder.ReminderAttendees.Add(New MailAddress("invited@example.com"))
        reminder.TriggerBeforeStart = New TimeSpan(2, 0, 0, 0) ' Remind two days before the event

        ' Add reminder to the event.
        e.Reminders.Add(reminder)

        ' Add event to the calendar.
        calendar.Events.Add(e)

        ' Create new task.
        Dim task As Task = New Task
        task.Organizer = New MailAddress("info@gemboxsoftware.com", "GemBox Ltd")
        task.Name = "Implement iCalendar support"
        task.Start = new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        task.Deadline = new DateTime(2018, 1, 15, 0, 0, 0, DateTimeKind.Utc)
        task.Priority = 5
        task.Categories.Add("new format support")
        task.Attendees.Add(New MailAddress("programmer@gemboxsoftware.com"))

        ' Add task to the calendar.
        calendar.Tasks.Add(task)

        calendar.Save("Save.ics")

    End Sub

End Module