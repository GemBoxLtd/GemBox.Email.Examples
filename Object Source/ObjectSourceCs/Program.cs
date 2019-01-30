using System.Collections.Generic;
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
        List<DataObject> data = new List<DataObject>()
        {
            new DataObject("jonh@example.com", "Mr.", "John", "Doe", 10, "https://example.com/check.html?name=John"),
            new DataObject("jane@example.com", "Mrs.", "Jane", "Doe", 20, "https://example.com/check.html?name=Jane"),
            new DataObject("joe@example.com", "Mr.", "Joe", "Unknown", 15, "https://example.com/check.html?name=Joe")
        };

        // Perform mail merge.
        IList<MailMessage> messages = MailMerge.Merge(template, data);

        // Save mail messages.
        for (int i = 0; i < messages.Count; i++)
            messages[i].Save($"Message_{i}.eml");
    }
}

// Custom data source type.
class DataObject
{
    public string To { get; }
    public string Title { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public int Discount { get; }
    public string Link { get; }

    public DataObject(string to, string title, string firstName, string lastName, int discount, string link)
    {
        this.To = to;
        this.Title = title;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Discount = discount;
        this.Link = link;
    }
}