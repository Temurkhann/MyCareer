using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MyCareer.Service.Helpers;

public static class HttpContextHelper
{
    public static IHttpContextAccessor Accessor { get; set; }
    public static HttpContext HttpContext => Accessor?.HttpContext;
    public static IHeaderDictionary ResponseHeaders => HttpContext?.Response?.Headers;
    public static long? UserId => GetUserId();
    public static string UserRole => HttpContext?.User.FindFirst("Role")?.Value;

    private static long? GetUserId()
    {
        string value = HttpContext?.User?.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value;

        bool canParse = long.TryParse(value, out long id);
        return canParse ? id : null;
    }
}
