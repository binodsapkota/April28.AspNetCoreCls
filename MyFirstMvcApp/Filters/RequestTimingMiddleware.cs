namespace MyFirstMvcApp.Filters
{
    public class RequestTimingMiddleware
    {
        // This middleware can be used to log the time taken for each request.
        // You can implement the Invoke method to measure the time and log it.
        // Example:
        private readonly RequestDelegate _next;
        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var startTime = DateTime.UtcNow;
            // Call the next middleware in the pipeline
            await _next(context);
            var endTime = DateTime.UtcNow;
            var duration = endTime - startTime;
            // Log the request timing
            Console.WriteLine($"Request took {duration.TotalMilliseconds} ms");
        }
    }
}
