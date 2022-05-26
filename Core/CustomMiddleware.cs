using Core.Services;

namespace Core
{
        public class CustomMiddleware
        {
                private RequestDelegate _next;
                private IResponseFormatter _formatter;

                public CustomMiddleware(RequestDelegate next, IResponseFormatter formatter)
                {
                        _next = next;
                        _formatter = formatter;
                }

                public async Task Invoke(HttpContext context)
                {
                        if (context.Request.Path == "/middleware")
                        {
                                await _formatter.Format(context, "Custom Middleware");
                        }
                        else
                        {
                                await _next(context);
                        }
                }
        }
}
