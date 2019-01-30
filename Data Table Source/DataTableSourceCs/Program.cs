using System.Collections.Generic;
using System.Data;
using GemBox.Email;

class Program
{
    static void Main()
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create template message.
        MailMessage template = new MailMessage("sender@example.com");
        template.Subject = "%FirstName%, check our new offer!";
        template.BodyHtml =
@"<div>
Dear <strong>%Title% %LastName%</strong><br/><br/>
Check out our new offer on this <a href=""%link%"">link</a>.<br/>
<span style=""color:red;font-size:90%"">Visit us today and get additional %discount%% discount!</span><br/><br/>
Sincerely Yours,<br/>
Special Store<br/><br/>
<span style=""color:gray;font-size:80%"">This email was sent to <a href=""mailto:%To%"">%To%</a>.</span>
</div>";

        // Create data source.
        DataTable data = new DataTable();
        data.Columns.Add("To", typeof(string));
        data.Columns.Add("Title", typeof(string));
        data.Columns.Add("FirstName", typeof(string));
        data.Columns.Add("LastName", typeof(string));
        data.Columns.Add("Discount", typeof(int));
        data.Columns.Add("Link", typeof(string));

        // Fill data source with some data.
        data.Rows.Add("jonh@example.com", "Mr.", "John", "Doe", 10, "https://example.com/check.html?name=John");
        data.Rows.Add("jane@example.com", "Mrs.", "Jane", "Doe", 20, "https://example.com/check.html?name=Jane");
        data.Rows.Add("joe@example.com", "Mr.", "Joe", "Unknown", 15, "https://example.com/check.html?name=Joe");

        // Perform mail merge operation.
        IList<MailMessage> messages = MailMerge.Merge(template, data);

        // Save mail messages.
        for (int i = 0; i < messages.Count; i++)
            messages[i].Save($"Message_{i}.eml");
    }
}