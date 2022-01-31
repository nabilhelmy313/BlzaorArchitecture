using BlazorArchitecture.Interfaces;
using BlazorArchitecture.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArchitecture
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //builder.Services.AddScoped<HttpClient>(s =>
            //{
            //    var client = new HttpClient { BaseAddress = new System.Uri("https://localhost:44340/") };
            //    return client;
            //});
            builder.Services.AddScoped<IFirstSerivce, FirstService>();
            await builder.Build().RunAsync();
        }
    }
}
