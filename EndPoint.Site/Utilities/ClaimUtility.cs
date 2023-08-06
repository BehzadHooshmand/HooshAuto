using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.Site.Utilities
{
    public static class ClaimUtility
    {
        public static string? GetUserEmail(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;

                if (claimsIdentity.FindFirst(ClaimTypes.Email) != null)
                {
                    string userEamil = (claimsIdentity.FindFirst(ClaimTypes.Email).Value);
                    return userEamil;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                return null;
            }

        }
    }
}
