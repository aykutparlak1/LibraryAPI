using System.Security.Claims;

namespace Core.Utilities.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? ClaimId(this ClaimsPrincipal claimsPrincipal)
        {
            var result = claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return result;
        }
    }
}
