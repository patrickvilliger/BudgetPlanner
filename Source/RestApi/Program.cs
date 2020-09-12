using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Unity;
using Unity.Microsoft.DependencyInjection;

namespace RestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder().Build().Run();
        }

        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }

        public static void Run(IUnityContainer container)
        {
            CreateHostBuilder(container).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(IUnityContainer container)
        {
            return Host.CreateDefaultBuilder()
                .UseUnityServiceProvider(container)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
