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

namespace Memory
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }
        public Startup()
        {
            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(new Dictionary<string, string>
            {
                {"Color", "Blue" },
                {"Content", "Memory configuration is currently show." }
            });
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
