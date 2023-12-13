using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace BedarfsCheck
{
    public class Program
    {        
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddEnvironmentVariables("").Build();
#if !DEBUG
            var url = config["ASPNETCORE_URLS"] ?? "http://*:8080";
            Global.SetConfig();
#endif
            //var url = "http://*:80";

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
#if !DEBUG
                .UseUrls(url)
#endif
                .Build();

            host.Run();
        }
    }
}
