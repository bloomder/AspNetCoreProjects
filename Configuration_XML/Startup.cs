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

namespace Configuration_XML
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(env.ContentRootPath);
            builder.AddXmlFile("XMLConfig.xml");
            AppConfiguration = builder.Build();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Run(async (context)=>
            {
                await context.Response.WriteAsync($"<p style='color:{AppConfiguration["Color"]};'>{AppConfiguration["Content"]}</p>");
            });
        }
    }
}
