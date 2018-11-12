using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace SIS_Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string jsonText = File.ReadAllText("appsettings.development.json");
            JObject jObject = JObject.Parse(jsonText);

            string connStr = jObject.GetValue("ConnectionString").ToString();

            {
                Students stuList = new Students();

                List<Students> students = stuList.GetAllStudents();

                CreateWebHostBuilder(args).Build().Run();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>();
        
    }
}
