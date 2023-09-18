using System.Security.Claims;

namespace Core.Utilities.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        private static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims(ClaimTypes.Role);
        }
        public static string? ClaimId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.ToString();
        }
    }
}
