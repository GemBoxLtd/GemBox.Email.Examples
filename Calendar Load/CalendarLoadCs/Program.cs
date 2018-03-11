using System;
using System.Text;
using GemBox.Email;
using GemBox.Email.Calendar;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Load calendar
        Calendar calendar = Calendar.Load("Simple.ics");
        StringBuilder sb = new StringBuilder();

        // Write a calendar method specifying what the calendar is used for.
        sb.AppendLine(string.Format("Method: {0}", calendar.Method));

        sb.AppendLine(string.Format("Count of events: {0}", calendar.Events.Count));
        sb.AppendLine(string.Format("Count of tasks: {0}", calendar.Tasks.Count));

        // Iterate through all events.
        foreach (Event e in calendar.Events)
        {
            sb.AppendLine("---------EVENT----------");
            sb.AppendLine(string.Format("Organizer: {0}", e.Organizer));
            sb.AppendLine(string.Format("Name: {0}", e.Name));
            sb.AppendLine(string.Format("Start: {0:G}", e.Start));
            sb.AppendLine(string.Format("End: {0:G}", e.End));

            sb.AppendLine(string.Format("Count of reminders: {0}", e.Reminders.Count));

            // Iterate through all reminders.
            foreach (Reminder reminder in e.Reminders)
            {
                sb.AppendLine("  --------REMINDER---------");
                sb.AppendLine(string.Format("  Action: {0}", reminder.ReminderAction));
                sb.AppendLine(string.Format("  Days to trigger before start: {0}", reminder.TriggerBeforeStart?.Days));
            }
        }

        // Iterate through all tasks.
        foreach (Task task in calendar.Tasks)
        {
            sb.AppendLine("---------TASK-----------");
            sb.AppendLine(string.Format("Organizer: {0}", task.Organizer));
            sb.AppendLine(string.Format("Name: {0}", task.Name));
            sb.AppendLine(string.Format("Start: {0:G}", task.Start));
            sb.AppendLine(string.Format("Deadline: {0:G}", task.Deadline));

            sb.AppendLine(string.Format("Count of reminders: {0}", task.Reminders.Count));

            // Iterate through all reminders.
            foreach (Reminder reminder in task.Reminders)
            {
                sb.AppendLine("  --------REMINDER---------");
                sb.AppendLine(string.Format("  Action: {0}", reminder.ReminderAction));
                sb.AppendLine(string.Format("  Days to trigger before start: {0}", reminder.TriggerBeforeStart?.Days));
            }
        }

        Console.WriteLine(sb.ToString());
    }
}