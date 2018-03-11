Imports System
Imports System.Text
Imports GemBox.Email
Imports GemBox.Email.Calendar

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Load calendar
        Dim calendar as Calendar = Calendar.Load("Simple.ics")
        Dim sb As StringBuilder = New StringBuilder
        
        ' Write a calendar method specifying what is the calendar used for
        sb.AppendLine(String.Format("Method: {0}", calendar.Method))
        sb.AppendLine(String.Format("Count of events: {0}", calendar.Events.Count))
        sb.AppendLine(String.Format("Count of tasks: {0}", calendar.Tasks.Count))
        
        ' Iterate through all events
        For Each e As [Event] In calendar.Events
            sb.AppendLine("---------EVENT----------")
            sb.AppendLine(String.Format("Organizer: {0}", e.Organizer))
            sb.AppendLine(String.Format("Name: {0}", e.Name))
            sb.AppendLine(String.Format("Start: {0:G}", e.Start))
            sb.AppendLine(String.Format("End: {0:G}", e.End))
            sb.AppendLine(String.Format("Count of reminders: {0}", e.Reminders.Count))
        
            ' Iterate through all reminders
            For Each reminder As Reminder In e.Reminders
                sb.AppendLine("  --------REMINDER---------")
                sb.AppendLine(String.Format("  Action: {0}", reminder.ReminderAction))
                sb.AppendLine(String.Format("  Days to trigger before start: {0}", reminder.TriggerBeforeStart?.Days))
            Next
        Next
        
        ' Iterate through all tasks
        For Each task As Task In calendar.Tasks
            sb.AppendLine("---------TASK-----------")
            sb.AppendLine(String.Format("Organizer: {0}", task.Organizer))
            sb.AppendLine(String.Format("Name: {0}", task.Name))
            sb.AppendLine(String.Format("Start: {0:G}", task.Start))
            sb.AppendLine(String.Format("Deadline: {0:G}", task.Deadline))
            sb.AppendLine(String.Format("Count of reminders: {0}", task.Reminders.Count))
        
            ' Iterate through all reminders
            For Each reminder As Reminder In task.Reminders
                sb.AppendLine("  --------REMINDER---------")
                sb.AppendLine(String.Format("  Action: {0}", reminder.ReminderAction))
                sb.AppendLine(String.Format("  Days to trigger before start: {0}", reminder.TriggerBeforeStart?.Days))
            Next
        Next

        Console.WriteLine(sb.ToString)

    End Sub

End Module