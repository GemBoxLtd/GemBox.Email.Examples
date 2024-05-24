Imports GemBox.Email
Imports GemBox.Email.Calendar
Imports System

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new calendar.
        Dim calendar As New Calendar()

        ' Create new event.
        Dim ev As New [Event]()
        ev.Organizer = New MailAddress("info@gemboxsoftware.com", "GemBox Ltd.")
        ev.Name = "GemBox Meeting Request"
        ev.Location = "152 City Road, London"
        ev.Start = New DateTime(2018, 1, 10, 9, 0, 0, DateTimeKind.Utc)
        ev.End = New DateTime(2018, 1, 12, 18, 0, 0, DateTimeKind.Utc)
        ev.Attendees.Add(New MailAddress("invited@example.com"))

        ' Create new reminder.
        Dim reminder As New Reminder()
        reminder.ReminderAction = ReminderAction.Email
        reminder.ReminderAttendees.Add(New MailAddress("invited@example.com"))
        reminder.TriggerBeforeStart = New TimeSpan(2, 0, 0, 0)

        ' Add reminder to the event.
        ev.Reminders.Add(reminder)

        ' Add event to the calendar.
        calendar.Events.Add(ev)

        ' Create new task.
        Dim task As New Task()
        task.Organizer = New MailAddress("info@gemboxsoftware.com", "GemBox Ltd.")
        task.Name = "Implement iCalendar Support"
        task.Start = New DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        task.Deadline = New DateTime(2018, 1, 15, 0, 0, 0, DateTimeKind.Utc)
        task.Priority = 5
        task.Categories.Add("New '.ics' format support")
        task.Attendees.Add(New MailAddress("programmer@example.com"))

        ' Add task to the calendar.
        calendar.Tasks.Add(task)

        calendar.Save("Create And Save.ics")
    End Sub
End Module
