using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace MicroserviceTemplate.Projection.Service
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                // Add your projectors here
            });
        }
    }
}
