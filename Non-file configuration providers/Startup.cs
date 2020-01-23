using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Non_file_configuration_providers
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            //string[] args = { "name=Alice", "age=35" };
            //var builder = new ConfigurationBuilder().AddCommandLine(args);
            ////AppConfiguration = builder.Build();
            //AppConfiguration = config;

            var builder = new ConfigurationBuilder()
           .AddInMemoryCollection(new Dictionary<string, string>
           {
                {"color", "red"},
                {"text", "Hello ASP.NET 5"}
           });
            AppConfiguration = builder.Build();
        }
        IConfiguration AppConfiguration { get; set; }
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var color = AppConfiguration["color"];
            var text = AppConfiguration["text"];
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"<center><h1 style='color:{color};'>{text}</h1>");
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(AppConfiguration["name"] + AppConfiguration["age"]);
            //});
        }
    }
}
