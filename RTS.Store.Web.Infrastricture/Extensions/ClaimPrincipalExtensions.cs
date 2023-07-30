namespace RTS.Store.Web.Infrastricture.Extensions
{
    using System.Security.Claims;

    public static class ClaimPrincipalExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
