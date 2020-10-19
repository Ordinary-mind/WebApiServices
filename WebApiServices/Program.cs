using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApiServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            SetConfigConsts();
            BuildWebHost(args).Run();
            
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls(ConfigConsts.StartHost)
                .UseStartup<Startup>()
                .Build();

        public static void SetConfigConsts()
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("conf.json").Build();
            ConfigConsts.StartHost = config["startHost"];
        }
    }
}
