using Microsoft.AspNetCore.Builder;
using Nancy.Owin;
using Microsoft.Extensions.Logging;

namespace GameNancy
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, ILoggerFactory LoggerFactory)
        {
            LoggerFactory.AddConsole();
            app.UseOwin(x => x.UseNancy());
        }
    }
}