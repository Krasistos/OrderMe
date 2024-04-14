using System.Security.Claims;
using static OrderMe.Core.Constants.AdministratorConstants;

public static class ClaimsPrincipalExtensions
{

    public static bool IsAdmin(this ClaimsPrincipal user)
    {
        return user != null &&
               user.Identity != null &&
               user.Identity.IsAuthenticated &&
               user.IsInRole(AdminRole);
    }


}
