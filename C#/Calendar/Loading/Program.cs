using GemBox.Email;
using GemBox.Email.Calendar;
using System;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Load calendar.
        Calendar calendar = Calendar.Load("Simple.ics");

        Console.WriteLine("CALENDAR");
        Console.WriteLine($"Method: {calendar.Method}");
        Console.WriteLine($"Events count: {calendar.Events.Count}");
        Console.WriteLine($"Tasks count: {calendar.Tasks.Count}");

        // Iterate through all events.
        Console.WriteLine();
        foreach (Event ev in calendar.Events)
        {
            Console.WriteLine("- EVENT");
            Console.WriteLine($"Organizer: {ev.Organizer}");
            Console.WriteLine($"Name: {ev.Name}");
            Console.WriteLine($"Start: {ev.Start:G}");
            Console.WriteLine($"End: {ev.End:G}");
            Console.WriteLine($"Reminders count: {ev.Reminders.Count}");

            // Iterate through all reminders.
            foreach (Reminder reminder in ev.Reminders)
            {
                Console.WriteLine("-- REMINDER");
                Console.WriteLine($"Action: {reminder.ReminderAction}");
                Console.WriteLine($"Days to trigger before start: {reminder.TriggerBeforeStart?.Days}");
            }
        }

        // Iterate through all tasks.
        Console.WriteLine();
        foreach (Task task in calendar.Tasks)
        {
            Console.WriteLine("- TASK");
            Console.WriteLine($"Organizer: {task.Organizer}");
            Console.WriteLine($"Name: {task.Name}");
            Console.WriteLine($"Start: {task.Start:G}");
            Console.WriteLine($"Deadline: {task.Deadline:G}");
            Console.WriteLine($"Reminders count: {task.Reminders.Count}");

            // Iterate through all reminders.
            foreach (Reminder reminder in task.Reminders)
            {
                Console.WriteLine("-- REMINDER");
                Console.WriteLine($"Action: {reminder.ReminderAction}");
                Console.WriteLine($"Days to trigger before start: {reminder.TriggerBeforeStart?.Days}");
            }
        }
    }
}
