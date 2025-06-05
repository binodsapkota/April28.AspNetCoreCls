using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using System.Xml.Serialization;

namespace FiltersInAspNet.Filters
{
    public class JsonResultFilter : IResultFilter
    {

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // No action needed after result execution for this filter
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            // If the result is not already a JsonResult, convert it to JSON
            if (context.Result is ObjectResult objectResult)
            {
                var json = JsonSerializer.Serialize(objectResult.Value);
                context.Result = new ContentResult
                {
                    Content = json,
                    ContentType = "application/json",
                    StatusCode = objectResult.StatusCode ?? 200
                };
            }
        }
    }
    public class XmlResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            // No action needed after result execution for this filter
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var serializer = new XmlSerializer(objectResult.Value?.GetType() ?? typeof(object));
                using var stringWriter = new StringWriter();
                serializer.Serialize(stringWriter, objectResult.Value);
                var xml = stringWriter.ToString();

                context.Result = new ContentResult
                {
                    Content = xml,
                    ContentType = "application/xml",
                    StatusCode = objectResult.StatusCode ?? 200
                };
            }
        }
    }
}
