using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersInAspNet.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Log the exception or handle it as needed
            // For example, you can log it using a logger or return a custom error response

            context.Result = new Microsoft.AspNetCore.Mvc.ContentResult
            {
                Content = "An error occurred while processing your request.",
                StatusCode = 500
            };

            context.ExceptionHandled = true; // Mark the exception as handled
        }

        // You can also implement OnExceptionAsync if you need asynchronous handling
        // public Task OnExceptionAsync(ExceptionContext context) => Task.CompletedTask;
    }

}
