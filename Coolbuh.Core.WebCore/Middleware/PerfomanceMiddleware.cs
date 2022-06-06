using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Coolbuh.Core.WebCore.Middleware
{
    /// <summary>
    /// Промежуточное ПО измерения производительности
    /// </summary>
    public class PerfomanceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<PerfomanceMiddleware> _logger;

        public PerfomanceMiddleware(RequestDelegate next, ILogger<PerfomanceMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();
            await _next.Invoke(context);
            watch.Stop();
            LogUserException(context.Request.Path, context.Request.Method, watch.ElapsedMilliseconds);
        }

        private void LogUserException(string controller, string method, long ms)
        {
            _logger.LogInformation(
                "Controller: {controller}" +
                "Method: {method}" +
                "ms: { ms}",
                controller, method, ms);
        }
    }

    /// <summary>
    /// Подключение промежуточного ПО измерения производительности
    /// </summary>
    public static class PerfomanceMiddlewareExtensions
    {
        public static void UsePerfomanceMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<PerfomanceMiddleware>();
        }
    }
}
