﻿using projectQuotesWebApi.Middlewares;

namespace projectQuotesWebApi.Extensions;

public static class LoggingMiddlewareExtensions
{
    public static IServiceCollection AddLoggingMiddleware(this IServiceCollection services)
    {
        return services.AddTransient<LoggingMiddleware>();
    }

    public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LoggingMiddleware>();
    }

}