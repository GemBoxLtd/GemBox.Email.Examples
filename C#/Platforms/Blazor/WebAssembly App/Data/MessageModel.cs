namespace BlazorWebAssemblyApp.Data
{
    public class MessageModel
    {
        public string Sender { get; set; } = "sender@example.com";
        public string Receiver { get; set; } = "receiver@example.com";
        public string Subject { get; set; } = "Example Message";
        public string Message { get; set; } =
            "This is an example message created with " +
            "<a href='https://www.gemboxsoftware.com/email'>GemBox.Email</a> from " +
            "<strong style='color:red'>Blazor WebAssembly</strong> application!";
    }
}