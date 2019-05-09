using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Gembox.SaveMessage
{
    public class Program
    {
        public static void Main()
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
