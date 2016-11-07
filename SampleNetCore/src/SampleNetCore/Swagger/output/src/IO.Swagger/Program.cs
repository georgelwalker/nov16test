using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace IO.Swagger
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var config = new ConfigurationBuilder()
                .AddEnvironmentVariables("")
            .Build();
			
			var url = config["ASPNETCORE_URLS"] ?? "http://*:8080";
		 
            var host = new WebHostBuilder()
                .UseKestrel(options =>
                {
                    // options.ThreadCount = 4;
                    // options.UseHttps("cert.pfx", "certpassword");
                    options.NoDelay = true;
                    options.UseConnectionLogging();
                })
                .UseUrls(url)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
