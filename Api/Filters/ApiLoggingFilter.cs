using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Api.Filters
{
    public class ApiLoggingFilter : IActionFilter
    {
        private ILogger<ApiLoggingFilter> Logger { get; }

        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {
            Logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logger.LogInformation("=== Executing -> OnActionExecuting");
            Logger.LogInformation("==================================");
            Logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            Logger.LogInformation("==================================");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Logger.LogInformation("=== Executed -> OnActionExecuted");
            Logger.LogInformation("==================================");
            Logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            Logger.LogInformation("==================================");
        }
    }
}