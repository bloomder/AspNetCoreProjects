using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace GetSection_Json
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(env.ContentRootPath);
            builder.AddJsonFile("JsonConfig.json");
            AppConfiguration = builder.Build();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            IConfigurationSection sections = AppConfiguration.GetSection("Company");
            string companyName = sections.GetSection("Name").Value;
            string companyDevelopers = sections.GetSection("Employees").Value;
            app.Run(async (context)=>
            {
                await context.Response.WriteAsync($"<br>Company: {companyName}.</br>");
                await context.Response.WriteAsync($"<br>Developers: {companyDevelopers}.</br>");
            });
        }
    }
}
