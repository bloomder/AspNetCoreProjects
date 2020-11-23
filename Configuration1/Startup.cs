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

namespace Configuration1
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }
        public Startup()
        {
            var builder = new ConfigurationBuilder();

            builder.AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "Name", "Bill"},
                    { "Surname", "Gates" }
                });
            AppConfiguration = builder.Build();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string name = $"<br>Name: {AppConfiguration["Name"]}<br>";
            string surname = $"<br>Surname: {AppConfiguration["Surname"]}<br>";
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(name + surname);
            });
        }
    }
}
