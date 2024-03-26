using Microsoft.AspNetCore.Mvc.Filters;

namespace DockerLearning.Scripts
{
    public class ClearTokenCookie : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // This method is called before the action method is executed
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // This method is called after the action method is executed

            // Access HttpContext from the context parameter
            var httpContext = context.HttpContext;

            // Check if the user has navigated away from the AdminPage
            if (!httpContext.Request.Path.Value.Equals("/AdminPage", StringComparison.OrdinalIgnoreCase))
            {
                // Clear the "token" cookie
                httpContext.Response.Cookies.Delete("token");
            }
        }
    }
}
