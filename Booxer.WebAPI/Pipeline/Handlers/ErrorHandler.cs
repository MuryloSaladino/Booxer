using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Booxer.Domain.Common;
using Booxer.Domain.Enums;

namespace Booxer.WebAPI.Pipeline.Handlers;

public static class ErrorHandlerExtensions
{
    public static void UseErrorHandler(this IApplicationBuilder app) =>
        app.UseExceptionHandler(error =>
        {
            error.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if(contextFeature is null) return;

                context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)(contextFeature.Error switch
                {
                    BaseException appError => appError.ExceptionCode,
                    _ => ExceptionCode.InternalServerError,
                });

                await context.Response.WriteAsync(contextFeature.Error switch
                {
                    BaseException appError => appError.ToMessage(),
                    _ => JsonSerializer.Serialize(new
                    {
                        message = "Internal Server Error",
                        code = 500
                    }),
                });
            });
        });
}