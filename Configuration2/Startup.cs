using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration2
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }
        public Startup()
        {
            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(new Dictionary<string, string>
            {
                {"ApplicationName", null },
                {"EnvironmentName", null }
            });
            AppConfiguration = builder.Build();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AppConfiguration["ApplicationName"] = env.ApplicationName;
            AppConfiguration["EnvironmentName"] = env.ContentRootPath;

            string AppName = $"<br>Application name: {AppConfiguration["ApplicationName"]}<br>";
            string EnvName = $"<br>Environment name: {AppConfiguration["EnvironmentName"]}<br>";
            
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(AppName + EnvName);
            });
        }
    }
}
