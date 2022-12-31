
using Microsoft.AspNetCore;

namespace Back.Rest.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
         WebHost.CreateDefaultBuilder(args)
         .ConfigureAppConfiguration((context, builder) =>
         {
             string dirSettings = "settings";
             if (!Directory.Exists(dirSettings))
             {
                 Directory.CreateDirectory(dirSettings);
             }


             foreach (var actualFile in Directory.EnumerateFiles(dirSettings))
             {
                 builder.AddJsonFile(actualFile, true, true);
             }

         })
         .UseStartup<Startup>();
    }
}
