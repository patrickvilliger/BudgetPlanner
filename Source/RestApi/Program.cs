using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RestApi
{
    public class Program
    {
        public static void Main()
        {
            CreateHostBuilder().Build().Run();
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseUrls("https://localhost:45002/");
                });
        }
    }
}
