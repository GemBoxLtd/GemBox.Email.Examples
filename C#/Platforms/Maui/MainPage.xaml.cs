using GemBox.Email;
using GemBox.Email.Imap;

namespace EmailMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly DataModel model;

        static MainPage()
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = model = new DataModel();
        }

        private MailMessage GetMessage()
        {
            using (var imap = new ImapClient(model.Host))
            {
                imap.Connect();
                imap.Authenticate(model.Username, model.Password);

                imap.SelectInbox();
                return imap.GetMessage(1);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            button.IsEnabled = false;
            activity.IsRunning = true;

            var message = await Task.Run(GetMessage);
            await DisplayAlert("Message",
                "\nSUBJECT: " + message.Subject +
                "\nFROM: " + message.From.ToString() +
                "\nDATE: " + message.Date.ToString(),
                "Close");

            activity.IsRunning = false;
            button.IsEnabled = true;
        }
    }

    public class DataModel
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}