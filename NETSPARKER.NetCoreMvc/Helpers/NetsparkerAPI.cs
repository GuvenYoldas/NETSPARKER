using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NETSPARKER.NetCoreMvc.Helpers
{
    public class NetsparkerAPI
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                    .Build();

        public static HttpClient client = new HttpClient();

        static NetsparkerAPI()
        {
            client.BaseAddress = new Uri(Configuration["AppSettings:ApiUrl"]);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
