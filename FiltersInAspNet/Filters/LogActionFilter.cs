using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersInAspNet.Filters
{
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogger<LogActionFilter> _logger;
        public LogActionFilter(ILogger<LogActionFilter> logger )
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Finished action: {Action}", context.ActionDescriptor.DisplayName);
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Starting action: {Action}", context.ActionDescriptor.DisplayName);
        }
    }
}
