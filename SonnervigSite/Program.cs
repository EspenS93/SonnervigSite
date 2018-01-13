using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SonnervigSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel(options =>
            {
                options.Listen(IPAddress.Loopback, 5000, listenOptions =>
                {
                    listenOptions.UseHttps("sonnervig.no.pfx", "Arefjord123");
                });
                options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                {
                    listenOptions.UseHttps("sonnervig.com.pfx", "Arefjord123");
                });
                options.Listen(IPAddress.Loopback, 5002, listenOptions =>
                {
                    listenOptions.UseHttps("espen.sonnervig.no.pfx", "Arefjord123");
                });
            })
            .UseStartup<Startup>()
            .Build();
    }
}
