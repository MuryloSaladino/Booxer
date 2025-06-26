using Booxer.WebAPI.Constants;

namespace Booxer.WebAPI.Pipeline.Middlewares;

public class SessionMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        var requestAccessToken = context.Request.Cookies[Cookies.AccessToken];
        var requestRefreshToken = context.Request.Cookies[Cookies.RefreshToken];

        var session = context.RequestServices.GetRequiredService<Domain.Identity.ISessionContext>();
        session.AccessToken = requestAccessToken;
        session.RefreshToken = requestRefreshToken;

        context.Response.OnStarting(() =>
        {
            if (session.AccessToken != requestAccessToken)
                context.UpdateToken(Cookies.AccessToken, session.AccessToken, DateTime.UtcNow.AddMinutes(15));

            if (session.RefreshToken != requestRefreshToken)
                context.UpdateToken(Cookies.RefreshToken, session.RefreshToken, DateTime.UtcNow.AddDays(30));

            return Task.CompletedTask;
        });

        await next(context);
    }
}


public static class CookiesExtensions
{
    public static void UpdateToken(this HttpContext context, string cookie, string? value, DateTime ExpiresAt)
    {
        if (value is string token)
        {
            context.Response.Cookies.Append(cookie, token, new CookieOptions
            {
                HttpOnly = true,
                Secure = context.Request.IsHttps,
                SameSite = SameSiteMode.Strict,
                Expires = ExpiresAt,
            });
        }
        else
        {
            context.Response.Cookies.Append(cookie, string.Empty, new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(-1),
            });
        }
    }
}