using System.Security.Claims;

namespace Core.Utilities.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        private static string Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal.FindFirst(claimType).Value;
            return result;
        }
        public static string ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims(ClaimTypes.Role);
        }
        public static string? ClaimId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
