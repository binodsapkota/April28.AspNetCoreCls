using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyFirstMvcApp.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;
        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "An error occurred in the application.");

            context.Result = new RedirectToActionResult("Error", "Home", null);
        }
    }
}
