namespace webApi.excepts;

public static class HttpResponseExceptionExtension
{
    public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<HttpResponseExceptionFilter>();
        }
}
