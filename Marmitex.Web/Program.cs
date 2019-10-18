using System.Web.Mvc;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Marmitex.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine($"Error: {e.Message}");      
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
