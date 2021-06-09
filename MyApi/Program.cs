using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Text;

namespace MyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                using (FileStream fs = File.Create("c:\\Temp\\errorStart.txt"))
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes(ex.Message);
                    fs.Write(title, 0, title.Length);
                }
                throw;
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
               WebHost.CreateDefaultBuilder(args)
                   .UseIISIntegration()
                   .UseStartup<Startup>();
    }
}