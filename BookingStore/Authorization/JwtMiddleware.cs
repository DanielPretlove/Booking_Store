
using BookingStore.Authorization;
using Microsoft.Extensions.Options;

namespace BookingStore.Helpers
{
    public class JwtMiddleware
    {
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, AccountContext accountContext, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var accountId = jwtUtils.ValidateJwtToken(token);
        if (accountId != null)
        {
            // attach account to context on successful jwt validation
            context.Items["Account"] = await accountContext.Accounts.FindAsync(accountId.Value);
        }

        await _next(context);
    }
    }

}