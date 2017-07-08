using System;
using System.Data;
using System.Collections.Generic;
using GemBox.Email;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create template message
        MailMessage template = new MailMessage(new MailAddress("sender@example.com"));
        template.Subject = "%FirstName%, check our new offer ...";
        template.BodyText = "Dear %Title% %LastName%,\r\n" +
                            "\r\n" +
                            "Check out or new offer on %link%.\r\n" +
                            "Visit us today and get additional %discount%% discount!\r\n" +
                            "\r\n" +
                            "Your,\r\n" +
                            "Special Store\r\n" +
                            "\r\n" +
                            "This email was sent to %To%.";
        template.BodyHtml = "<div>" +
                                "Dear <strong>%Title% %LastName%</strong>,<br/>" +
                                "<br/>" +
                                "Check out our new offer on this <a href=\"%link%\">link</a>.<br/>" +
                                "<span style=\"color:red;font-size:90%\">Visit us today and get additional %discount%% discount!</span><br/>" +
                                "<br/>" +
                                "Sincerly Yours,<br/>" +
                                "Special Store<br/>" +
                                "<br/>" +
                                "<span style=\"color:gray;font-size:80%\">This email was sent to <a href=\"mailto:%To%\">%To%</a>.</span>" +
                            "</div>";

        // Define data table columns ...
        DataTable data = new DataTable();
        data.Columns.Add("To", typeof(string));
        data.Columns.Add("Title", typeof(string));
        data.Columns.Add("FirstName", typeof(string));
        data.Columns.Add("LastName", typeof(string));
        data.Columns.Add("Discount", typeof(int));
        data.Columns.Add("Link", typeof(string));

        // ... and add some data
        data.Rows.Add("jonh@example.com", "Mr.", "John", "Doe", 10, "http://example.com/check.html?name=John");
        data.Rows.Add("jane@example.com", "Mrs.", "Jane", "Doe", 20, "http://example.com/check.html?name=Jane");
        data.Rows.Add("joe@example.com", "Mr.", "Joe", "Unknown", 15, "http://example.com/check.html?name=Joe");

        // Perform mail merge
        IList<MailMessage> messages = MailMerge.Merge(template, data);

        // Save messages to disk
        for (int i = 0; i < messages.Count; i++)
            messages[i].Save("Message_" + i, MailMessageFormat.Eml);
    }
}
