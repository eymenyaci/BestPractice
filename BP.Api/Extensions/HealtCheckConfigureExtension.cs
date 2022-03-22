using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Api.Extensions
{
    public static class HealtCheckConfigureExtension
    {
        public static IApplicationBuilder UseCustomHealtCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/api/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
            {
                ResponseWriter = async (context, report) =>
                {
                    await context.Response.WriteAsync("OK");
                }
            }); // HealtCheck Control

            return app;
        }
    }
}
